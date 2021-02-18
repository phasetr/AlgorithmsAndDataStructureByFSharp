# ## P.21 Challenge 12: Add
# 2 つの引数 `num1`, `num2` を持つ関数 `add` を定義する.
# 引数の数を足してそれを返す.

function add(num1, num2)
  num1 + num2
end

function main_021()
  println("1 つ目の数を入力してください.")
  num1_in = parse(Int, readline())
  println("2 つ目の数を入力してください.")
  num2_in = parse(Int, readline())
  total = add(num1_in, num2_in)
  println("2 つの数の和は $(total) です.")
end

# main_021()
