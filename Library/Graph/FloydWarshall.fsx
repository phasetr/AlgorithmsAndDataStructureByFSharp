#r "nuget: FsUnit"
open FsUnit

@"Floyd-Warshall for int[][]"
let fw1 iN jN kN (Ga:int[][]) =
  let Ra = array2D Ga
  for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ra.[i,j] <- min Ra.[i,j] (Ra.[i,k]+Ra.[k,j])
  Ra

@"Floyd-Warshall for int[,]"
let fw2 iN jN kN (Ga:int[,]) =
  let Ra = Array2D.copy Ga
  for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ra.[i,j] <- min Ra.[i,j] (Ra.[i,k]+Ra.[k,j])
  Ra

@"Floyd-Warshall for Dictionary<int*int,int>"
let fw3 iN jN kN (Ga:System.Collections.Generic.Dictionary<(int*int), int>) =
  for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ga.[(i,j)] <- min Ga.[(i,j)] (Ga.[(i,k)]+Ga.[(k,j)])
  Ga
