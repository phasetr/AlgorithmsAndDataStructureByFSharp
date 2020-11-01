# ## P.18 Challenge 10: Subject Shortner
# 学校の時間割では科目名はよく先頭の三文字に省略される.
# 例えば Math は Mat, French は Fre, Music は Mus と省略する.
# 科目名から省略形を作る関数を書け.

function subj_shortener(subj)
  subj[begin:begin+2]
end
println("Math -> $(subj_shortener("Math"))")
println("French -> $(subj_shortener("French"))")
println("Music -> $(subj_shortener("Mus"))")
