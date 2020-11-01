# ## P.009 Challenge 3: Options
# 関数の引数ごとに次の文字列を返すようにする
#
# 1. Computer Science
# 2. Music
# 3. Dance
# 4. PE
#
# 上以外の入力の場合は Error を返すようにする
function options(num)
  if num == 1 return "Computer Science"
  elseif num == 2 return "Music"
  elseif num == 3 return "Dance"
  elseif num == 4 return "PE"
  else return "Error" end
end
println(map(i -> "$i: $(options(i))", 0:6))

# ## P.010 Challenge 4: Calling Options
# 上の options を呼ぶ処理を追加する
function call_options()
  println("options を呼び出すために整数値を入力してください。")
  num = parse(Int, readline())
  println(options(num))
end
# call_options()
