# https://atcoder.jp/contests/tessoku-book/submissions/37122525
# Initialize
(n, m), *E = [[*map(int, l.split())] for l in open(0)]
adj = [set() for _ in range(n+1)]
for v, u, c in E:
    adj[v].add(u)
    adj[u].add(v)
cap = [[0]*(n+1) for _ in range(n+1)]
for v, u, c in E: cap[v][u] = c

# Ford-Fulkerson
def get_flow_dfs(v, t, F) -> int:
    if v == t: return F
    visited[v] = True

    for u in [u for u in adj[v] if not visited[u] and cap[v][u]]:
        if (flow := get_flow_dfs(u, t, min(F, cap[v][u]))) > 0 :
            cap[v][u] -= flow
            cap[u][v] += flow
            return flow

    # No valid path
    return 0

(ans, flow) = (0, -1)
while flow:
    visited = [False] * (n+1)
    ans += (flow:=get_flow_dfs(1, n, INF:=5000))
print(ans)

