def solve(n,m,E):
    adj = [set() for _ in range(n)]
    for v, u, c in E:
        adj[v-1].add(u-1)
        adj[u-1].add(v-1)
    cap = [[0]*n for _ in range(n)]
    for v, u, c in E: cap[v-1][u-1] = c

    def get_flow_dfs(v, t, F) -> int:
        if v == t: return F
        visited[v] = True

        for u in [u for u in adj[v] if not visited[u] and cap[v][u]]:
            if (flow := get_flow_dfs(u, t, min(F, cap[v][u]))) > 0 :
                cap[v][u] -= flow
                cap[u][v] += flow
                return flow

        return 0

    (ans, flow) = (0, -1)
    while flow:
        visited = [False] * n
        ans += (flow:=get_flow_dfs(0, n-1, INF:=5000))
    return ans

def main():
    (n, m), *E = [[*map(int, l.split())] for l in open(0)]
    print(solve(n,m,E))
main()

(n,m,E) = 6,7,[[1,2,5],[1,4,4],[2,3,4],[2,5,7],[3,6,3],[4,5,3],[5,6,5]]
print(solve(n,m,E) == 8)
