a,b = input().split()
print(a if (int(a[-1])<int(b[-1])) else b)

a = "323"
b = "334"
print(int(a[-1]) < int(b[-1]))
a,b = "17 51".split()
print(a[-1])
