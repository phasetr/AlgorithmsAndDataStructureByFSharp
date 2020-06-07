// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_3_C&lang=jp
#include <cstdio>
#include <cstdlib>
#include <cstring>
using namespace std;

struct Node {
  int key;
  Node *next, *prev;
};

Node *sentinel;

Node *listSearch(int key) {
  Node *cur = sentinel->next;  // Trace the next element from the sentinel
  while (cur != sentinel && cur->key != key) {
    cur = cur->next;
  }
  return cur;
}

void init() {
  sentinel = (Node *)malloc(sizeof(Node));
  sentinel->next = sentinel;
  sentinel->prev = sentinel;
}

void printList() {
  Node *cur = sentinel->next;
  int isf = 0;
  while (true) {
    if (cur == sentinel) break;
    if (isf++ > 0) printf(" ");
    printf("%d", cur->key);
    cur = cur->next;
  }
  printf("\n");
}

void deleteNode(Node *t) {
  if (t == sentinel) return;  // No process for the sentinel
  t->prev->next = t->next;
  t->next->prev = t->prev;
  free(t);
}

void deleteFirst() { deleteNode(sentinel->next); }
void deleteLast() { deleteNode(sentinel->prev); }

void deleteKey(int key) {
  // Delete the searched node
  deleteNode(listSearch(key));
}

void insert(int key) {
  Node *x = (Node *)malloc(sizeof(Node));
  x->key = key;
  x->next = sentinel->next;
  sentinel->next->prev = x;
  sentinel->next = x;
  x->prev = sentinel;
}

int main() {
  int key, n, i;
  int size = 0;
  char com[20];

  scanf("%d", &n);

  init();
  for (i = 0; i < n; i++) {
    scanf("%s%d", com, &key);
    if (com[0] == 'i') {
      insert(key);
      size++;
    } else if (com[0] == 'd') {
      printf("%s\n", com);
      if (strlen(com) > 6) {
        if (com[6] == 'F') {
          deleteFirst();
        } else if (com[6] == 'L') {
          deleteLast();
        }
      } else {
        deleteKey(key);
      }
      size--;
    }
  }

  printList();

  return 0;
}
