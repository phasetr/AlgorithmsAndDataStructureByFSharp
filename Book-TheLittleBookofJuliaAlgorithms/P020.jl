# ## P.20 Challenge 1:: Volume of a Cuboid
# 直方体（cuboid）の縦・横・高さを引数にとり、直方体の体積を計算する関数を書く.

function vol_of_cuboid(l, w, h)
  l * w * h
end

function main_020()
  println("縦の長さを整数で入力してください.")
  l = parse(Int, readline())
  println("横の長さを整数で入力してください.")
  w = parse(Int, readline())
  println("高さの長さを整数で入力してください.")
  h = parse(Int, readline())
  vol = vol_of_cuboid(l, w, h)
  println("直方体の面積は $(vol) です.")
end

# main_020()
