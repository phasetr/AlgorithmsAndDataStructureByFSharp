#r "nuget: FsUnit"
open FsUnit

@"cf.
./Arithmetics.fsx
./References.fsx, module Operator"

module SystemMath =
  let near0 x y = (abs (x-y)) < 0.0000001

  "Atan, 逆正接, arctan, atan
  https://docs.microsoft.com/ja-jp/dotnet/api/system.math.atan?view=net-6.0
  See atan in the above `module Math`."
  near0 (System.Math.Atan 1) 0.7853981634 |> should be True
  near0 (atan 1) 0.7853981634 |> should be True

  @"PI, 円周率
  https://docs.microsoft.com/ja-jp/dotnet/api/system.math.atan?view=net-6.0"
  near0 System.Math.PI 3.141592654 |> should be True

module SystemNumerics =
  open System.Numerics

  @"System.Numerics.Complex, complex number, 複素数
  https://numerics.mathdotnet.com/api/MathNet.Numerics/Complex32.htm"
  System.Numerics.Complex.Zero |> should equal (System.Numerics.Complex(0,0))
  System.Numerics.Complex.One |> should equal (System.Numerics.Complex(1,0))
  System.Numerics.Complex.ImaginaryOne |> should equal (System.Numerics.Complex(0,1))
  System.Numerics.Complex(1,0).Real |> should equal 1.0
  System.Numerics.Complex(1,0).Imaginary |> should equal 0.0
  System.Numerics.Complex(1,0).Magnitude |> should equal 1.0
  System.Numerics.Complex(1,0).Phase |> should equal 0.0

  let c1 = Complex(1,2)
  let c2 = Complex(3,4)
  c1*c2 |> should equal (Complex(-5,10))
  Complex(4,0) / Complex(2,0) |> should equal (Complex(2,0))
