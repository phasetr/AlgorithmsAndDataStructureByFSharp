// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/2128385/c7c7/C++
#include <iostream>
#define Z -1
using namespace std;
struct NO{int p,l,r;};
struct NO T[100000];
int D[100000]={Z};
int rec(int u,int p){
    D[u]=p;
    if(T[u].r!=Z)rec(T[u].r,p);
    if(T[u].l!=Z)rec(T[u].l,p+1);
    return 0;
}
int main(){
    int a,b,c,n,l,r,j,k,i;
    for(cin>>n,i=0;i<n;i++)T[i].p=T[i].l=T[i].r=Z;
    for(i=0;i<n;i++)for(cin>>a>>b,j=0;j<b;j++){
            cin>>c;
            if(!j)T[a].l=c;
            else T[l].r=c;
            l=c;
            T[l].p=a;
        }
    for(i=0;i<n;i++)if(T[i].p==Z)r=i;
    rec(r,0);
    for(i=0;i<n;i++){
        printf("node %d: parent = %d, depth = %d, ",i,T[i].p,D[i]);
        if(T[i].p==Z)cout<<"root, [";
        else if(T[i].l==Z)cout<<"leaf, [";
        else cout<<"internal node, [";
        for(j=0,c=T[i].l;c!=Z;c=T[c].r){
            if(j++)cout<<", ";
            cout<<c;
        }
        cout<<"]"<<endl;
    }
}
