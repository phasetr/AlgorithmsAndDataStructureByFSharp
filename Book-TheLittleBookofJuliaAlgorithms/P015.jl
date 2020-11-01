# ## P.15 String Concatenation: Making a Username
# Joseph Campbell 2015 を 15JCampbell に変換する
module P015
function username(first_name, last_name, year)
  username_out = year[begin+2:begin+3] * first_name[begin] * last_name
  "Your username is $(username_out)"
end

function main()
  println("あなたの名を入力してください:")
  first_name = readline()
  println("あなたの姓を入力してください:")
  last_name = readline()
  println("あなたが入学した西暦を教えてください:")
  joined = readline()
  println(username(first_name, last_name, joined))
end
end
P015.main()
