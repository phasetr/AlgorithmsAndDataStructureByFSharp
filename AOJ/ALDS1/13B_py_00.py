# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/5106135/salmon0852/Python3
from collections import deque

def swap(s,i,j):
    ls = list(s)
    ls[i], ls[j] = ls[j], ls[i]
    return ''.join(ls)

def solve(init):
    # 処理をゴールの状態からはじめて入力の状態に持っていく形にする
    goal = ''.join([str(i) for i in range(1, 9)]) + '0' # 123456780
    ng = [[2,3],[3,2],[5,6],[6,5]] # 0オリジンでの交換できない盤面上の場所

    used = {goal : 0}
    que = deque([[goal, 8, 0]]) # state: パズルの状態, p: 0の位置, cnt: 交換回数

    # 交換した状態はキューの後ろに追加: 後ろに交換回数の多い状態がどんどん積まれる
    # 交換回数が少ないキューの前から適切な状態かチェックする
    while que:
        state, zero_pos, cnt = que.popleft()
        if state == init:
            ans = cnt
            break

        # val: 0の場所を見て交換できる盤面上の位置
        # 適切にカウントアップしながらパズルの状態・0の位置・交換回数を記録して試行キューに追加
        for change_pos in [chg for chg in [zero_pos-1, zero_pos+1, zero_pos-3, zero_pos+3]
                           if 0 <= chg <= 8 and [zero_pos, chg] not in ng]:
            tmp = swap(state, zero_pos, change_pos)
            if tmp in used:
                continue
            que.append([tmp, change_pos, cnt+1])
            used[tmp] = cnt + 1

    return ans

init = ''
for i in range(3): init += input().replace(' ', '')
print(solve(init))

init = "130425786"
print(solve("130425786") == 4)
