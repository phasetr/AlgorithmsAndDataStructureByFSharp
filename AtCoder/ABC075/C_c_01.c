// https://atcoder.jp/contests/abc075/submissions/5098743
#include<stdio.h>
int main() {
  int n, m;
  scanf("%d %d", &n, &m);
  int i;
  int a[55], b[55];
  for (i = 0; i < m; i++){
    scanf("%d %d", &a[i], &b[i]);
    a[i]--;
    b[i]--;
  }
  int ans = 0;
  int j, k;
  int x;
  int v[55];
  for (i = 0; i < m; i++){
    for (j = 0; j < n; j++){ v[j] = 0; }
    v[0] =1;
    for (j = 0; j < m; j++){
      for (k = 0; k < m; k++){
        if (i != k){
          if (v[a[k]] > 0){v[b[k]] = 1;}
          if (v[b[k]] > 0){v[a[k]] = 1;}
        }
      }
    }
    x = 0;
    for (j = 0; j < n; j++){
      if (v[j] == 0){
        x++;
      }
    }
    if (x > 0){ans++;}
  }
  printf("%d\n", ans);
  return 0;
}
