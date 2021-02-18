# ## P.19 Calculate the Area of a Circle
# 円周率
println(pi) # π
pi
println(π)
π

function circle_area(r_in)
  pi * r_in^2
end

function area_of_circle()
  println("円の半径を入力してください.")
  r = parse(Int, readline())
  area = circle_area(r)
  println("円の面積は $(area) です.")
end

# area_of_circle()
