# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/2721890/kyuna/Python3
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

def find(target):
    result = root
    while result and target != result.key:
        result = result.left if target < result.key else result.right
    return result is None

def delete(target):
    def remove_node(p, c, a):
        if p.left == c: p.left = a
        else: p.right = a
    p, c = None, root
    while c.key != target: p, c = c, c.left if target < c.key else c.right
    if c.left is None:
        remove_node(p, c, c.right)
    elif c.right is None:
        remove_node(p, c, c.left)
    elif c.right.left is None:
        c.right.left = c.left
        remove_node(p, c, c.right)
    else:
        g = c.right
        while g.left.left: g = g.left
        c.key = g.left.key
        g.left = g.left.right

def inorder(node):
    return inorder(node.left) + f' {node.key}' + inorder(node.right) if node else ''
def preorder(node):
    return f' {node.key}' + preorder(node.left) + preorder(node.right) if node else ''

input()
for e in sys.stdin:
    if e[0] == 'i': insert(int(e[7:]))
    elif e[0] == 'd': delete(int(e[7:]))
    elif e[0] == 'f': print(['yes','no'][find(int(e[5:]))])
    else: print(inorder(root)); print(preorder(root))
