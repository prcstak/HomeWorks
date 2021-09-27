.assembly IL
{
  .ver 1:0:0:0
}

.class public abstract auto ansi sealed beforefieldinit IL.Class
  extends [CORE_ASSEMBLY]System.Object
{
  .method public hidebysig static int32 Square(int32 a, int32 b) cil managed
  {
    .maxstack 2
    ldarg.0
    ldarg.1
    mul
    ret
  }
}