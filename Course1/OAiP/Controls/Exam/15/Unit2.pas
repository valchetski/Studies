unit Unit2;

interface

Type
TInf = record
  k:integer;
  f:shortstring;
end;

mas = array[1..14] of TInf;
PTree = ^Tree;
Tree = record
  inf:TInf;
  A1:PTree;
  A2:PTree;
end;

TTree = class(TObject)
   proot,w,p,q:PTree;
   constructor Create();
   procedure AddB(inf:Tinf);
   procedure blns(a:mas; n:integer);
   function minkB:Tinf;

end;

implementation

constructor TTree.Create();
begin
inherited Create;
proot:=nil;
end;

procedure TTree.AddB(inf:TInf);
begin
New(w);
w.inf:=inf;
w.A1:=nil;
w.A2:=nil;
if proot = nil then proot:=w
else
 begin
  p:=proot;
  repeat
   q:=p;
   if inf.k<p.inf.k then p:=p.A1
                    else p:=p.A2;
  until p = nil;
  if inf.k<q.inf.k then q.A1:=w
                   else q.A2:=w;
 end;
end;

procedure Ttree.blns(a:mas; n:integer);
  procedure wr(l,r:integer);
    var i:integer;
    begin
      if l<=r then
        begin
      i:=(l+r)div 2;
      addB(a[i]);
      wr(1,i-1);
      wr(i+1,r);
        end;
    end;
begin
  wr(1,n);
end;


function Ttree.minkB():TInf;
  begin
    p:=proot;
    while p.A1<> nil do p:=p.A1;
    result:=p.inf;
  end;


end.
