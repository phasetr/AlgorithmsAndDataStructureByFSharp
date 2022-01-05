struct RetStruct
  cnt
  a
  g
  RetStruct(cnt, a, g) = new(cnt, a, g)
end

# 間隔 g を指定した挿入ソート
function inssort(a, g, cnt)
  n = length(a)
  for i in g:n
    v = a[i]
    j = i - g
    while (j >= 1 && a[j] > v)
      a[j+g] = a[j]
      j -= g
      cnt += 1
    end
  end
  RetStruct(cnt, a, [])
end

function shellsort(a)
  n = length(a)
end
