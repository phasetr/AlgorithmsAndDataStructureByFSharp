// https://atcoder.jp/contests/abc129/submissions/6024706
open System
open System.Collections.Generic

let [|h; w|] = stdin.ReadLine().Split(' ') |> Array.map int
let s = Array.create h ""
for i = 0 to h - 1 do
  s.[i] <- stdin.ReadLine().Trim()
let dw = new List<List<int>>()
let dh = new List<List<int>>()
for i = 0 to h - 1 do
  let cw = new List<int>()
  let mutable count = 0
  for j = 0 to w - 1 do
    if s.[i].[j] = '#' then
      cw.Add(0)
    elif (j = 0 || s.[i].[j - 1] = '#') then
      count <- let rec loop1 i k w (s : string []) count =
                 if k > w - 1 || s.[i].[k] <> '.' then
                   count
                 else
                   loop1 i (k + 1) w s (count + 1)
               in loop1 i j w s 0
      cw.Add(count)
    else
      cw.Add(count)
  dw.Add(cw)
for j = 0 to w - 1 do
  let ch = new List<int>()
  let mutable count = 0
  for i = 0 to h - 1 do
    if s.[i].[j] = '#' then
      ch.Add(0)
    elif (i = 0 || s.[i - 1].[j] = '#') then
      count <- let rec loop2 k j h (s : string []) count =
                 if k > h - 1 || s.[k].[j] <> '.' then
                   count
                 else
                   loop2 (k + 1) j h s (count + 1)
               in loop2 i j h s 0
      ch.Add(count)
    else
      ch.Add(count)
  dh.Add(ch)
let mutable max = 0
for i = 0 to h - 1 do
  for j = 0 to w - 1 do
    let sum = dw.[i].[j] + dh.[j].[i]
    if max < sum then
      max <- sum
Console.WriteLine(max - 1)
