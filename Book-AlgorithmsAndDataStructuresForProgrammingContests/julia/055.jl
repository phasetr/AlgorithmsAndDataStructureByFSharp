trace(x) = println(x')
input = [5,2,4,6,1,3]

function inssort(a)
  # Julia は 1 はじまりだから C++ と添え字がずれる
  # 実際の動きは P.56 の図を見て確認しよう
  for i in 2:length(a)
    v = a[i]
    j = i - 1
    while(j >= 1 && a[j] > v)
      a[j+1] = a[j]
      j -= 1
    end
    a[j+1] = v
    trace(a)
  end
end
trace(input)
inssort(input)
