unit Unit2;

interface
uses sysutils, math;
type
  Tset = Set of byte;
  goods = record w,c:integer end;
  mas=array [1..20] of goods;
  Tchoice=class(Tobject)
    N:Byte; //число элементов
    CWmas:mas;
    s,Optimal_Choice:Tset;
	  Wmax,Cmax:word;
    Procedure Vetvi_granici(i:byte;wt,cost:word); //Метод ветвей и границ
    Procedure PP(I:byte; Full_Weight,Full_Cost:word);  //Полный перебор
    Procedure Max_Cost(); //Метод максимальной стоимости
    Procedure Min_Weight(); //Метод минимального веса
    Procedure Balanced_Cost(); //Метод сбалансированной стоимости
    Procedure Random_Search(); //Метод случайного поиска
  end;
implementation

Procedure Tchoice.Vetvi_granici;
var wt1,cost1:Word;
begin
  wt1:=wt+CWmas[i].w;
  if wt1<=Wmax then
    begin
	  	Include(S,i);
		  if i<n then Vetvi_granici(i+1,wt1,cost)
        else
          if cost>Cmax then begin Cmax:=cost; Optimal_Choice:=S end;
     	Exclude(S,i);
    end;
  cost1:=cost-CWmas[i].c;
  if cost1>Cmax then
	if i<n then Vetvi_granici(i+1,wt,cost1)
	  else begin Cmax:=cost1; Optimal_Choice:=S end;
end;

Procedure Tchoice.PP;
begin
  Include(s,i);
  Full_Weight:=Full_Weight+CWmas[i].w;
  Full_Cost:=Full_Cost+CWmas[i].c;
  if i<n then PP(i+1,Full_Weight,Full_Cost)
    else if (Full_Weight<=Wmax) and (Full_Cost>Cmax) then
      begin Cmax:=Full_Cost; Optimal_Choice:=S; end;
  Exclude(s,i);
  Full_Weight:=Full_Weight-CWmas[i].w;
  Full_Cost:=Full_Cost-CWmas[i].c;
  if i<n then PP(i+1,Full_Weight,Full_Cost)
    else if (Full_Weight<=Wmax) and (Full_Cost>Cmax) then
      begin Cmax:=Full_Cost; Optimal_Choice:=S; end;
End;

Procedure Tchoice.Max_Cost(); //Метод максимальной стоимости
Var mc:extended; i:byte; Full_Weight,Full_Cost:word;
Function Imax():byte; // Элемент с максимальной стоимостью,
var i:Byte;          //ещё не вошедший в Optimal_Choice
Begin
  mc:=0;
  for i:=1 to n do
   if not(i in Optimal_Choice) and (CWmas[i].c>mc) then
  	begin mc:=CWmas[i].c; Imax:=i end;
end;
Begin
  Full_Weight:=0; Full_Cost:=0;
  Optimal_Choice:=[]; i:=Imax(); Full_Weight:=0; Full_Cost:=0;
  while Full_Weight+CWmas[i].w<=Wmax do
   begin Include(Optimal_Choice,i);
    Full_Weight:=Full_Weight+CWmas[i].w; Full_Cost:=Full_Cost+CWmas[i].c;
    i:=Imax();
   end;
  Cmax:=Full_Cost;
end;

Procedure Tchoice.Min_Weight;
Var mw:extended; i,k,Full_Weight,Full_Cost:word;
Function Imin():word; // Элемент с минимальным весом
var i:Byte;
Begin
  mw:=Wmax;
  for i:=1 to n do
   if not(i in Optimal_Choice) and (CWmas[i].w<mw) then
   	begin mw:=CWmas[i].w; Imin:=i end;
end;
Begin
  Full_Weight:=0; Full_Cost:=0;
 i:=Imin; k:=1;
 while (k<=n) and (Full_Weight+CWmas[i].w<=wmax) do
   begin k:=k+1; Include(Optimal_Choice,i);
    Full_Weight:=Full_Weight+CWmas[i].w; Full_Cost:=Full_Cost+CWmas[i].c;
    i:=Imin;
   end;
 Cmax:=Full_Cost;
end;

Procedure Tchoice.Balanced_Cost;
Var mw:extended; i,k,Full_Weight,Full_Cost:word;
Function I_balanced():word;
var i:Byte;
Begin
  mw:=0;
  for i:=1 to n do
   if not(i in Optimal_Choice) and (CWmas[i].c/CWmas[i].w>mw) then
   	begin mw:=CWmas[i].c/CWmas[i].w; I_balanced:=i end;
end;
Begin
 Full_Weight:=0; Full_Cost:=0;
 i:=I_balanced(); k:=1;
 while (k<=n) and (Full_Weight+CWmas[i].w<=wmax) do
   begin k:=k+1; Include(Optimal_Choice,i);
    Full_Weight:=Full_Weight+CWmas[i].w; Full_Cost:=Full_Cost+CWmas[i].c;
    i:=I_balanced(); inc(k);
   end;
 Cmax:=Full_Cost;
end;

Procedure Tchoice.Random_Search;
Var i,j,k,Full_Weight,Full_Cost:word; Optimal_Choice_Bufer:Tset;
Function I_random():word; // cлучайный элемент, ещё не использованный
var m:Byte;
Begin
  repeat
    m:=random(n)+1;
  until not (m in Optimal_Choice_Bufer);
  result:=m;
end;
Begin
 Full_Weight:=0; Full_Cost:=0;
 randomize;
 Cmax:=0;
 Optimal_Choice_Bufer:=[];
 for j:=1 to n*20 do
 begin
   i:=I_random();
   k:=1;
   while (k<n) and (Full_Weight+CWmas[i].w<=wmax) do
     begin
       Include(Optimal_Choice_Bufer,i);
       Full_Weight:=Full_Weight+CWmas[i].w; Full_Cost:=Full_Cost+CWmas[i].c;
       i:=I_random();
       Inc(k);
     end;
   if Full_Cost>Cmax then begin Cmax:=Full_Cost; Optimal_Choice:=Optimal_Choice_Bufer; Optimal_Choice_Bufer:=[]; Full_Weight:=0; Full_Cost:=0 end
   else begin Optimal_Choice_Bufer:=[]; Full_Weight:=0; Full_Cost:=0 end
 end;
end;

end.
