unit Unit2;

interface

Type
TInf = record
  k:integer;
  f:shortstring;
end;

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
   function PoiskB(key:integer):TInf;
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

function TTree.PoiskB(key:integer):TInf;
begin
 p:=proot;
 while (p<>nil) and (p.inf.k<>key) do
  if key<p.inf.k then p:=p.A1
                 else p:=p.A2;
 if p = nil then result.f := 'Not Found!'
            else result:=p.inf;
end;

end.
