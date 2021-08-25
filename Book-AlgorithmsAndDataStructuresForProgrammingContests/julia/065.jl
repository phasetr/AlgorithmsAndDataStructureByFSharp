struct RetStruct
  count
  retval
  RetStruct(count, retval) = new(count, retval)
end

function selectionsort(a)
  minj = 1
  count = 0
  N = length(a)
  for i in 1:N
    minj = i
    for j in i:N
      minj = a[j] < a[minj] ? j : minj
    end
    a[i], a[minj] = a[minj], a[i]
    count = i != minj ? count+1 : count
  end
  return RetStruct(count, a)
end

input = [5,6,4,2,1,3]
selectionsort(input)
