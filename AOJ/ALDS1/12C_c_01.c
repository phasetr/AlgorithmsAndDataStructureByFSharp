// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/1021763/S1210001/C
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#define M 10000
#define E 500000

typedef struct edge {
    int from, to, cost;
} Ed;
Ed e[E];
int d[M];

void sp(int,int);

int main(int argc,char* argv[])
{
    int vn, en, an;
    int i, j, vi;
    scanf("%d", &vn);

    en=0;
    for(i=0; i<vn; i++) {
        scanf("%d", &vi);
        scanf("%d", &an);
        for(j=1; j<=an; j++) {
            e[en].from=vi;
            scanf("%d %d", &e[en].to, &e[en].cost);
            en++;
        }
    }

    sp(vn, en);
    for(i=0; i<vn; i++) {
        printf("%d %d\n", i, d[i]);
    }
    return 0;
}
void sp(int vn, int en)
{
    int i, new=1;
    for(i=1; i<vn; i++) d[i]=INT_MAX;

    while(new) {
        new=0;
        for(i=0; i<en; i++) {
            if(d[e[i].from] !=INT_MAX && d[e[i].from]+e[i].cost < d[e[i].to]) {
                d[e[i].to] = d[e[i].from]+e[i].cost;
                new++;
            }
        }
    }
}

