.assembly IL
{
  .ver 1:0:0:0
}

.class public abstract auto ansi sealed beforefieldinit IL.Calculator
  extends [CORE_ASSEMBLY]System.Object
{
  .method public hidebysig static int32 Calculate(
      string op,
      int32 arg1,
      int32 arg2
  ) cil managed
  {
    .maxstack 10
        
    ldarg.0
    ldstr "+"
    call bool System.String::op_Equality(string, string)
    brtrue plus
    
    ldarg.0
    ldstr "*"
    call bool System.String::op_Equality(string, string)
    brtrue mult
    
    ldarg.0
    ldstr "-"
    call bool System.String::op_Equality(string, string)
    brtrue subs
    
    ldarg.0
    ldstr "/"
    call bool System.String::op_Equality(string, string)
    brtrue divide
    
    ldc.i4.0
    ret
    
    plus:
    ldarg.1
    ldarg.2
    add
    ret
    
    mult:
    ldarg.1
    ldarg.2
    mul
    ret
    
    subs:
    ldarg.1
    ldarg.2
    sub
    ret
    
    divide:
    ldarg.1
    ldarg.2
    div
    ret
  }
}