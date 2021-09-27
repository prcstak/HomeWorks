.assembly IL
{
  .ver 1:0:0:0
}

.assembly extern System.Private.CoreLib{}
.assembly extern System.Console{}
.assembly extern System.Collections{}

.class public abstract auto ansi sealed beforefieldinit IL.Parser
  extends [CORE_ASSEMBLY]System.Object
{
  .method public hidebysig static int32 TryParseValues(
      string[] args,
      [out] int32& arg1,
      [out] int32& arg2,
      [out] string& op
    ) cil managed
  {
    .maxstack 8
       
    ldarg.0
    ldc.i4.0
    ldelem.ref
    ldarg.1
    call bool [System.Private.CoreLib]System.Int32::TryParse(string, int32&)
    brfalse.s exception1 
    
    ldarg.0
    ldc.i4.2
    ldelem.ref
    ldarg.2
    call bool [System.Private.CoreLib]System.Int32::TryParse(string, int32&)
    brfalse.s exception1
    
    ldarg.3
    ldarg.0
    ldc.i4.1
    ldelem.ref
    stind.ref

    
    ldarg.0
    ldc.i4.1
    ldelem.ref
    call bool IL.Parser::IsSupported(string) 
    brfalse.s exception2
    
    ldc.i4.0
    ret    
   
    exception1:
    ldc.i4.6
    newarr       System.String
    dup
    ldc.i4.0
    ldarg.0      
    ldc.i4.0
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.1
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.2
    ldarg.0    
    ldc.i4.1
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.3
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.4
    ldarg.0     
    ldc.i4.2
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.5
    ldstr        " invalid arguments."
    stelem.ref
    call         string System.String::Concat(string[])
    call         void [System.Console]System.Console::WriteLine(string)
    
    ldc.i4.1
    ret
    
    exception2:
    ldc.i4.6
    newarr       System.String
    dup
    ldc.i4.0
    ldarg.0     
    ldc.i4.0
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.1
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.2
    ldarg.0     
    ldc.i4.1
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.3
    ldstr        " "
    stelem.ref
    dup
    ldc.i4.4
    ldarg.0      
    ldc.i4.2
    ldelem.ref
    stelem.ref
    dup
    ldc.i4.5
    ldstr        " invalid operation."
    stelem.ref
    call         string System.String::Concat(string[])
    call         void [System.Console]System.Console::WriteLine(string)
     
    ldc.i4.2
    ret
  }
  .method private static hidebysig bool IsSupported(string operation) cil managed
  {
    .maxstack 2
    ldarg.0
    ldstr "+"
    call bool System.String::op_Equality(string, string)
    brtrue.s Supported

    ldarg.0
    ldstr "-"
    call bool System.String::op_Equality(string, string)
    brtrue.s Supported

    ldarg.0
    ldstr "/"
    call bool System.String::op_Equality(string, string)
    brtrue.s Supported

    ldarg.0
    ldstr "*"
    call bool System.String::op_Equality(string, string)
    brtrue.s Supported

    ldc.i4.0
    ret
    
    Supported:
    ldc.i4.1
    ret
  }
}
