n1 = 6
input1 = [5,3,1,3,4,3]
n2 = 3
input2 = [4,3,2]

function solve1(input)
  max_val = -200000
  for (i1, v1) in enumerate(input)
    for v2 in input[i1+1:end]
      max_val = max(v2 - v1, max_val)
    end
  end
  return max_val
end
println(solve1(input1))
println(solve1(input1) == 3)
println(solve1(input2))
println(solve1(input2) == -1)

function solve2(input)
  maxv = -200000
  minv = input[begin]
  # ループをはじめる位置に注意
  for v in input[begin+1:end]
    maxv = max(maxv, v - minv)
    minv = min(minv, v)
  end
  return maxv
end

println(solve2(input1))
println(solve2(input1) == 3)
println(solve2(input2))
println(solve2(input2) == -1)
