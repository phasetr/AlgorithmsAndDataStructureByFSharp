# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/1194000/tige/Python3
def left(i):  return 2*i+1
def right(i): return 2*i+2
def max_heapify(a, i):
    l = left(i)
    r = right(i)
    largest = l if l < len(a) and a[l] > a[i] else i
    largest = r if r < len(a) and a[r] > a[largest] else largest

    if largest != i:
        a[i], a[largest] = a[largest], a[i]
        max_heapify(a, largest)

def build_max_heap(a):
    for i in range(len(a) // 2, -1, -1):
        max_heapify(a, i)
n = int(input())
heap = list(map(int, input().split()))
build_max_heap(heap)
print('', *heap)
