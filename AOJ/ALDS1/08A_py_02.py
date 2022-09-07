# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/2721898/kyuna/Python3
import sys

class Node:
    __slots__ = ['key', 'left', 'right']
    def __init__(self, key):
        self.key = key
        self.left = self.right = None

root = None

def insert(key):
    global root
    x, y = root, None
    while x: x, y = x.left if key < x.key else x.right, x
    if y is None: root = Node(key)
    elif key < y.key: y.left = Node(key)
    else: y.right = Node(key)

def inorder(node):
    return inorder(node.left) + f' {node.key}' + inorder(node.right) if node else ''
def preorder(node):
    return f' {node.key}' + preorder(node.left) + preorder(node.right) if node else ''

input()
for e in sys.stdin:
    if e[0] == 'i': insert(int(e[7:]))
    else: print(inorder(root)); print(preorder(root))
