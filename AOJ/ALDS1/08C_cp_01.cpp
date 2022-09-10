// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/1800900/E869120/C++
#include<iostream>
#include<string>
using namespace std;
#define MAX_N 500000
#define INF 2139062143
int x[MAX_N][4], cnt; //num,left,right
int n, a; string S;
void inorder(int u) {
  if (u == -1) { return; }
  inorder(x[u][1]);
  cout << ' ' << x[u][0];
  inorder(x[u][2]);
}
void preorder(int u) {
  if (u == -1) { return; }
  cout << ' ' << x[u][0];
  preorder(x[u][1]);
  preorder(x[u][2]);
}
int Next(int a1) {
  a1 = x[a1][2];
  while (x[a1][1] != -1) {
    a1 = x[a1][1];
  }
  return a1;
}
int main() {
  int root = -INF; cin >> n;
  for (int i = 0; i < n; i++) {
    cin >> S;
    if (S == "delete") {
      cin >> a; int v = root;
      while (true) {
        if (a == x[v][0]) { a = v; goto D1; }
        if (a < x[v][0]) {
          if (x[v][1] == -1) { goto C1; } v = x[v][1];
        }
        if (a > x[v][0]) {
          if (x[v][2] == -1) { goto C1; } v = x[v][2];
        }
      }
    C1:; D1:;
      int Y = a, X = 0, Z = 0;
      if (x[a][1] != -1 && x[a][2] != -1) { Y = Next(a); }
      if (x[Y][1] != -1) {
        X = x[Y][1];
      }
      else { X = x[Y][2]; }
      if (X != -1) {
        x[X][3] = x[Y][3];
      }
      if (x[Y][3] == -1) { root = X; }
      else if (Y == x[x[Y][3]][1]) { x[x[Y][3]][1] = X; }
      else { x[x[Y][3]][2] = X; }
      if (Y != a) {
        x[a][0] = x[Y][0];
      }
    }
    if (S == "print") {
      inorder(root); cout << endl;
      preorder(root); cout << endl;
    }
    if (S == "find") {
      cin >> a; int v = root;
      while (true) {
        if (a == x[v][0]) { cout << "yes" << endl; goto D; }
        if (a < x[v][0]) {
          if (x[v][1] == -1) { goto C; } v = x[v][1];
        }
        if (a > x[v][0]) {
          if (x[v][2] == -1) { goto C; } v = x[v][2];
        }
      }
    C:; cout << "no" << endl; D:;
    }
    if (S == "insert") {
      cin >> a; int P = -1;
      if (root == -INF) { root = cnt; }
      else {
        int v = root;
        while (true) {
          if (a < x[v][0]) {
            if (x[v][1] == -1) { x[v][1] = cnt; P = v; goto E; }
            v = x[v][1]; P = v;
          }
          else {
            if (x[v][2] == -1) { x[v][2] = cnt; P = v; goto E; }
            v = x[v][2]; P = v;
          }
        }
      E:;
      }
      x[cnt][0] = a; x[cnt][1] = -1; x[cnt][2] = -1; x[cnt][3] = P; cnt++;
    }
  }
  return 0;
}
