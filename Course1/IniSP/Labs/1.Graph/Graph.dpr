program Graph;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  Windows;

type
  TGraph = class
    private
      fMatrix : array [0..100,0..100] of integer;
      fTop, fEdge : integer;
      procedure add_or_delete(line_edges : string; j : integer);
    public
      procedure input_graph(line_edges : string);
      procedure add_top(line_edges : string);
      procedure delete_top(delete : string);
      procedure delete_edge(line_edges : string);
      function watch : string;
      procedure clear;
  end;

procedure TGraph.add_or_delete; //��������� ��� ������� �����, � ���������� �� j
var
  i, element, hyphen, one_top, two_top : integer;
  temp : string;
begin
  element := 0; hyphen := 0; one_top := 0;
  for i := 1 to length(line_edges) do
  begin
    if hyphen <= fedge then
    begin
      if (line_edges[i] <> ' ') and (line_edges[i] <> '-') then
      begin
        temp := line_edges[i];
        inc(element);
        if element = 2 then
        begin
          two_top := strtoint(temp);
          temp := '';
          fmatrix[one_top-1, two_top-1] := j;
          fmatrix[two_top-1, one_top-1] := j;
          element := 0;
        end;
      end;
      if line_edges[i] = '-' then
      begin
        inc(hyphen);
        one_top := strtoint(temp);
        temp := '';
      end;
    end;
  end;
end;

procedure TGraph.input_graph; //������ ����
var
  j : integer;
begin
  clear;
  j := 1;
  add_or_delete(line_edges, j);
end;

procedure TGraph.add_top;//��������� ������� ��� �����
var
  j : integer;
begin
  j := 1;
  add_or_delete(line_edges, j);
end;

procedure Tgraph.delete_edge;  //������� �����
var
  j : integer;
begin
  j := 0;
  add_or_delete(line_edges, j);
end;

procedure Tgraph.delete_top( delete : string);//������� �������
var
  i, delete_top, row, col : integer;
  temp : string;
begin
  for i := 1 to length(delete) do
  begin
    if delete[i]<>' ' then
    begin
      temp := delete[i];
      delete_top := strtoint(temp);
      for col := delete_top - 1 to ftop - 1 do //������� �������
        for row := 0 to ftop - 1 do
          fmatrix[row, col] := fmatrix[row, col + 1];
      for row := delete_top - 1 to ftop - 1 do //������� ������
        for col := 0 to ftop - 1 do
          fmatrix[row, col] := fmatrix[row + 1, col];
      row := ftop - 1;
      for col := 0 to ftop -1 do//�������� ��������� ������
        fmatrix[row, col] := 0;
      col := ftop - 1;
      for row := 0 to ftop -1 do//�������� ��������� �������
        fmatrix[row, col] := 0;
      ftop := ftop - 1;
    end;
  end;
end;

function TGraph.watch;//�������� �����
var
  row, col, edge, i, j : integer;
  series_1, series_2 : array [0..100] of integer;
  output : string;
begin
  edge := 0; j := 0; output := '';
  for row := 0 to ftop - 1 do
    for col := 0 to ftop - 1 do
      if fmatrix[row, col] = 1 then
      begin
        inc(edge);
        series_1[j] := row;
        series_2[j] := col;
        inc(j);
      end;
   edge := edge div 2;
   if edge = 0 then
    ftop := 0;
   for i := 0 to j-1 do
      output := output + inttostr(series_1[i]+1) + '-' + inttostr(series_2[i]+1)+ ' ';
   output := '�������: ' + inttostr(ftop)+ ' �����: '+inttostr(edge)+' '+output;
   result := output;
end;

procedure tgraph.clear;
var
  i, j :integer;
begin
  for i := 0 to (ftop - 1) do
    for j := 0 to (ftop - 1) do
      fmatrix[i, j] := 0;
end;

var
  Graph1 : TGraph;
  choice, top, edge, i : integer;
  line_edges, delete : string;
begin
  SetConsoleCP(1251);
  SetConsoleOutPutCP(1251);
  Graph1 := TGraph.Create;
  writeln('                                ���� �����');
  writeln('������� ���������� ������: ');
  readln(top);
  Graph1.fTop := top;
  writeln('������� ���������� �����: ');
  readln(edge);
  Graph1.fEdge := Edge;
  writeln('������� �������(����� ������), ������� ����� ��������� �����(�������� 1-2): ');
  readln(line_edges);
  Graph1.input_graph(line_edges);
  while true do
  begin
    writeln;
    writeln('��� ������ ������?');
    writeln('1 - ������ ������ ����');
    writeln('2 - �������� ������� ��� �����');
    writeln('3 - ������� �������');
    writeln('4 - ������� �����');
    writeln('5 - �������� ������ � �����');
    writeln('6 - �������� ����');
    writeln('7 - ����������� ���������');
    writeln('0 - �����');
    writeln;
    readln(choice);
    case choice of
    1 : begin
          writeln('������� ���������� ������: ');
          readln(top);
          Graph1.fTop := top;
          writeln('������� ���������� �����: ');
          readln(edge);
          Graph1.fEdge := edge;
          writeln('������� �������(����� ������), ������� ����� ��������� �����(�������� 1-2): ');
          readln(line_edges);
          Graph1.input_graph(line_edges);
        end;
    2 : begin
          writeln('������� ���������� ������: ');
          readln(top);
          Graph1.fTop := top;
          writeln('����� ������� ��������� �������: ');
          readln(line_edges);
          Graph1.add_top(line_edges);
        end;
    3 : begin
        writeln('�������(����� ������) �������, ������� ����� �������: ');
        readln(delete);
        Graph1.delete_top(delete);
        end;
    4 : begin
          writeln('������� �������, ����� �������� ������� �����:');
          readln(line_edges);
          Graph1.delete_edge(line_edges);
        end;
    5 : writeln(Graph1.watch);
    6 : begin
          Graph1.clear;
          writeln('���� ������!');
        end;
    7 : begin
          i := 0;
          while i <=5 do
          begin
            inc(i);
            writeln('������� ���������� ������: ');
            readln(top);
            Graph1.fTop := top;
            writeln('������� ���������� �����: ');
            readln(edge);
            Graph1.fEdge := edge;
            writeln('������� �������, ������� ����� ��������� �����: ');
            readln(line_edges);
            Graph1.input_graph(line_edges);
            writeln(Graph1.watch);
          end;
        end;
    0 : break;
    end;
  end;
  Graph1.Destroy;
end.
