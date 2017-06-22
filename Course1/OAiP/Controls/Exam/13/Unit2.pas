unit Unit2;

interface

Uses Grids, SysUtils;

Type
Tinf = record
  f:shortstring;
  k:integer;
end;

PTree = ^Tree;
Tree = record
   inf:Tinf;
   A1:PTree;
   A2:PTree;
end;

TTree = class(TObject)
   proot,p,w,t,v,q:PTree;
   constructor Create();
   procedure AddB(inf:TInf);
   procedure Wrt1B(strg: TStringGrid);
end;

implementation

constructor TTree.Create();
begin
inherited Create();
proot:=nil;
end;

procedure TTree.AddB(inf: TInf);
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

procedure TTree.Wrt1B(strg: TStringGrid);
var
 i:word;

 procedure wr(p: PTree);
 begin
  if p<>nil then
   begin
   strg.Cells[0,i]:=IntToStr(p.inf.k);
   strg.Cells[1,i]:=p.inf.f;
   inc(i);
   wr(p.A1);
   wr(p.A2);
  end;
 end;

begin
i:=0;
wr(proot);
end;

end.
