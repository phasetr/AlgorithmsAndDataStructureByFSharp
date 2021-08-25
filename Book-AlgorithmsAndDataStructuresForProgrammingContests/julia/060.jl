struct RetStruct
  count
  retval
  RetStruct(count, retval) = new(count, retval)
end

function bubblesort(a)
  i = 1
  count = 0
  flag = true

  while flag
    flag = false
    j = N
    while j >= i+1
      # We need the exact inequality "<" for stability
      if a[j] < a[j-1]
        a[j], a[j-1] = a[j-1], a[j]
        flag = true
        count += 1
      end
      j -= 1
    end
    i += 1
  end
  return RetStruct(count, a)
end

input = [5,3,2,4,1]
bubblesort(input)
