using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace dotnet_practice10_26
{
    public static class EditorForModelExtension
    {
        public static IHtmlContent CustomEditorForModel(this IHtmlHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var model = helper
                .ViewData
                .ModelMetadata
                .ModelType;
            var props = model.GetProperties();
            var builder = new HtmlContentBuilder();

            foreach (var prop in props)
            {
                builder.AppendHtml(SerializeModelProp(prop, ValidateProp(prop, helper.ViewData.Model)));
            }

            return builder;
        }

        private static string SerializeModelProp(PropertyInfo prop, string validationResult)
        {
            var name = prop.GetCustomAttribute<DisplayAttribute>()?.GetName()
                       ?? Split.CamelCase(prop.Name);

            if (prop.PropertyType == typeof(string))
            {
                return $"<div class=\"editor-label col-md-3\"><label for=\"{prop.Name}\">{name}</label></div>" +
                       validationResult;
            }

            if (prop.PropertyType.IsEnum)
            {
                var fields = prop.PropertyType.GetFields();
                var options = "";
                options += $"<option selected=\"selected\" value=\"None\"> -- </option>";
                foreach (var field in fields)
                {
                    if (field.Name != "value__" && field.Name != "None")
                        options += $"<option value=\"{field.Name}\">{field.Name}</option>";
                }
                

                return
                    "<div class=\"editor-label col-md-3\">" + $"<label for=\"{prop.Name}\">{name}</label> <br> " +
                    "<select class=\"form-select is-invalid\"> <br>" +
                    $"{options}" +
                    "</select></div>";
            }

            if (prop.PropertyType.IsValueType)
            {
                return $"<div class=\"editor-label col-md-3\"><label for=\"{prop.Name}\">{name}</label></div>" +
                       validationResult;
            }

            return null;
        }

        private static string ValidateProp(PropertyInfo prop, object model)
        {
            var attribute = prop.GetCustomAttribute<ValidationAttribute>();
            var inputType = prop.PropertyType.IsValueType ? "number" : "text";
            var value = prop.GetValue(model);

            if (attribute == null && !prop.PropertyType.IsEnum)
                return
                    $"<div class=\"editor-field col-md-3\"><input class=\"form-control\" id=\"{prop.Name}\"" +
                    $" name=\"{prop.Name}\"" +
                    $" type=\"{inputType}\" value=\"{value}\"> <span class=\"field-validation-valid\" " +
                    $"data-valmsg-for=\"FirstName\" " +
                    "data-valmsg-replace=\"true\"></span></div>";
            
            

            if (attribute != null && attribute.IsValid(value))
                return
                    $"<div class=\"editor-field col-md-3 mb-2\"> <input class=\"form-control\"" +
                    $"data-val=\"true\" data-val-length={attribute.ErrorMessage}" +
                    $"data-val-length-max=\"10\" data-val-length-min=\"2\" id=\"{prop.Name}\"" +
                    $"maxlength=\"10\" name=\"{prop.Name}\" type=\"{inputType}\" value=\"{value}\"> " +
                    $"<span class=\"field-validation-valid\"" +
                    $"data-valmsg-for=\"{prop.Name}\" data-valmsg-replace=\"{true}\"></span></div>";

            return
                $"<div class=\"editor-field col-md-3 mb-2\"> <input class=\"form-control is-invalid\"" +
                $"data-val=\"true\" data-val-length={attribute?.ErrorMessage}" +
                $"data-val-length-max=\"10\" data-val-length-min=\"2\" id=\"{prop.Name}\"" +
                $"maxlength=\"10\" name=\"{prop.Name}\" type=\"{inputType}\" value=\"{value}\"> <span class=\"field-validation-error text-danger\"" +
                $"data-valmsg-for=\"{prop.Name}\" data-valmsg-replace=\"{true}\"><small>{attribute?.ErrorMessage}</small></span></div>";
        }
    }
}