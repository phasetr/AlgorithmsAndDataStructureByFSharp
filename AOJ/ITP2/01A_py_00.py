def solve(qs):
    s = []
    for q in qs:
        if q[0] == 0: # pushBack
            s.append(q[1])
        elif q[0] == 1: # randomAccess
            print(s[q[1]])
        else: # popBack
            s.pop()
    return s

def main():
    q = int(input())
    qs = [list(map(int, input().split())) for _ in range(q)]
    solve(qs)

main()

qs = [[0,1],[0,2],[0,3],[2],[0,4],[1,0],[1,1],[1,2]]
solve(qs)
