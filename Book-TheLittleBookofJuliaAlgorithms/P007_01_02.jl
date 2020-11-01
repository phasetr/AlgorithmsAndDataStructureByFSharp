# ## P.007 Challenge 1: Highest Number
# 3 つの数の中から最大の数を返す関数を作る
function highest_number(num1, num2, num3)
  retnum = num1
  if num2 <= num1 && num3 <= num1      retnum = num1
  elseif num1 <= num2 && num3 <= num2 retnum = num2
  else retnum = num3 end
  retnum
end
# テスト
for i in 1:3 for j in 1:3 for k in 1:3
  println("$((i,j,k)): $(highest_number(i,j,k))")
end end end

# ## P.008 Challenge 2: Calling Highest Number
function call_hn()
  println("第一の数整値を入力してください.")
  num1_in = parse(Int, readline())
  println("第二の数整値を入力してください.")
  num2_in = parse(Int, readline())
  println("第三の数整値を入力してください.")
  num3_in = parse(Int, readline())
  highest_number(num1_in, num2_in, num3_in)
end
println("最大値は次の数です: $(call_hn())")
