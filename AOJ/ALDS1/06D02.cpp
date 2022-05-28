// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/969578/dohatsu/C++
#include<iostream>
#include<map>
#include<algorithm>
using namespace std;
int main(){
    int n,ans=0,t[1000],u[1000];
    bool visited[1000];
    map<int,int> change;
    cin>>n;
    for(int i=0;i<n;i++){
        cin>>t[i];
        change[t[i]]=i;
        u[i]=t[i];
        visited[i]=false;
    }
    sort(u,u+n);
    for(int i=0;i<n;i++){
        int w=i,x=0,y=0,z=10000;
        while(!visited[w]){
            z=min(z,t[w]);
            y+=t[w];
            x++;
            visited[w]=true;
            w=change[u[w]];
        }
        if(x>=2)ans+=min(y+z+u[0]*(x+1),y+z*(x-2));
    }
    cout<<ans<<endl;
    return 0;
}
