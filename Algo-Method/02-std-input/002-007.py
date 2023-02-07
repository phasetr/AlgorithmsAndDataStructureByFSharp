s = input()
t = input()
print("Yes" if s==t else "No")

def test():
    print(("Yes" if "turtle" == "turtle" else "No") == "Yes")
    print(("Yes" if "algo" == "method" else "No") == "No")
