[<Measure>]
type M (* meter *)
let toMeters x = x * 1<M>
let ofMeters (x: float<M>) = x / 1.0<M>

[<Measure>]
type S (* second *)

[<Measure>]
type Kg (* kilogram *)

[<Measure>]
type N = (Kg * M) / S^2

[<Measure>]
type Pa = N / M^2

let distance = 100.0<M>
let time = 5.0<S>
let speed = distance / time

[<Measure>]
type C

[<Measure>]
type F

let toFahrenheit (x: float<C>) = x * (9.0<F> / 5.0<C>) + 32.0<F>
let toCelsius (x: float<F>) = (x - 32.0<F>) * (5.0<C> / 9.0<F>)

[<Measure>]
type Col

[<Measure>]
type Row

let colOffset (a: int<Col>) (b: int<Col>) = a - b
let rowOffset (a: int<Row>) (b: int<Row>) = a - b

// P.269 Generalizing Units of Measure
let average (l: float<'u> list) =
    ((0.0<_>, 0.0<_>), l)
    ||> List.fold (fun (sum, count) x -> sum + x, count + 1.0<_>)
    |> fun (sum, count) -> sum / count
let vanillaFloats = [10.0;15.5;17.0]
average vanillaFloats
let lengths = [2.0;7.0;14.0;5.0] |> List.map (fun a -> a*1.0<M>)
average lengths
let masses =  [155.54;179.01;135.90] |> List.map (fun a -> a * 1.0<Kg>)
average masses
let densities = [0.54;1.0;1.1;0.25;0.7] |> List.map (fun a -> a * 1.0<Kg/M^3>)
average densities
