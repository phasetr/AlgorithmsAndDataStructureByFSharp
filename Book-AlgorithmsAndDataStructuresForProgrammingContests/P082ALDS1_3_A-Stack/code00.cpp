#include <iostream>
using namespace std;

int top, S[1000];

void push(int x) {
  // Add a top variable and then push a value at the point
  S[++top] = x;
}

int pop() {
  top--;
  // Return the value pointed by top
  return S[top + 1];
}

int main() {
  int a, b;
  top = 0;
  char s[100];

  while (scanf("%s", s) != EOF) {
    if (s[0] == '+') {
      a = pop();
      b = pop();
      push(a + b);
    } else if (s[0] == '-') {
      b = pop();
      a = pop();
      push(a - b);
    } else if (s[0] == '*') {
      a = pop();
      b = pop();
      push(a * b);
    } else {
      push(atoi(s));
    }
  }

  cout << pop() << endl;

  return 0;
}
