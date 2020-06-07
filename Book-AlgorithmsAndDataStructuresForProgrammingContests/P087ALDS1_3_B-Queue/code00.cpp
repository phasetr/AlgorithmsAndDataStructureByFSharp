#include <algorithm>
#include <cstdio>
using namespace std;
static const int LEN = 100000;

struct pp {
  char name[100];
  int t;
};

pp Q[LEN];
int head, tail;

void enqueue(pp x) {
  Q[tail] = x;
  tail = (tail + 1) % LEN;
}

pp dequeue() {
  pp x = Q[head];
  head = (head + 1) % LEN;
  return x;
}

void debug(pp x) { printf("%s %d\n", x.name, x.t); }

int main() {
  int elaps = 0, c;
  int n, q;
  pp u;

  scanf("%d %d", &n, &q);

  for (int i = 0; i < n; i++) scanf("%s %d", Q[i].name, &Q[i].t);
  // for (int i = 0; i < n; i++) debug(Q[i]);

  head = 0;
  tail = n;

  while (head != tail) {
    u = dequeue();
    c = min(q, u.t);  // Process q or u.t
    u.t -= c;         // Calculate remained time
    elaps += c;       // Add process time
    if (u.t > 0) {
      // Added to queue if not finished
      enqueue(u);
    } else {
      printf("%s %d\n", u.name, elaps);
    }
  }

  return 0;
}
