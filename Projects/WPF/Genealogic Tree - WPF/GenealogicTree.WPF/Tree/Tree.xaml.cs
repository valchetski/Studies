using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GenealogicTree.BusinessLayer;
using GenealogicTree.Entities;

namespace GenealogicTree.WPF.Tree
{
    /// <summary>
    /// Interaction logic for Tree.xaml
    /// </summary>
    public partial class Tree
    {
        #region region

        private readonly double offset;
        private Vertex checkedVertex1;

        public Tree()
        {
            InitializeComponent();
            offset = 100;
        }

        public void AddNewFamilyMembers(Dictionary<Person, List<KindOfRelative>> allRelatives)
        {
            foreach (var keyValue in allRelatives)
            {
                var person = keyValue.Key;
                var kindOfRelativeList = keyValue.Value;
                var kindOfRelative = kindOfRelativeList[0];
                var vertex = new Vertex
                {
                    DataContext = person,
                    WhoIsRelativeTextBlock =
                    {
                        Text = ConvertTo.String(RelationshipsDictionary.GetKindOfRelative(kindOfRelativeList))
                    }
                };
                TreeCanvas.Children.Add(vertex);
                var checkedVertex = GetCheckedVertex();
                var point = CalculateCoordinates(vertex, checkedVertex, kindOfRelative);
                AddRelationship(vertex, checkedVertex, kindOfRelative);

                if ((point.X > ActualWidth) && ((double.IsNaN(Width)) || (point.X > Width)))
                {
                    Width = point.X;
                }

                if ((point.Y > ActualHeight) && ((double.IsNaN(Height)) || (point.X > Height)))
                {
                    Height = point.Y;
                }
            }
            RepositionAllObjects();
        }


        public void AddNewFamilyMember(Person person, KindOfRelative kindOfRelative)
        {
            var list = new List<KindOfRelative> {kindOfRelative};
            var checkedVertex = GetCheckedVertex();
            if (checkedVertex != null)
            {
                list.Add(ConvertTo.KindOfRelative(checkedVertex.WhoIsRelativeTextBlock.Text));
            }
            var vertex = new Vertex
            {
                DataContext = person,
                WhoIsRelativeTextBlock = {Text = ConvertTo.String(RelationshipsDictionary.GetKindOfRelative(list))}
            };
            TreeCanvas.Children.Add(vertex);

            var point = CalculateCoordinates(vertex, checkedVertex, kindOfRelative);
            AddRelationship(vertex, checkedVertex, kindOfRelative);
            vertex.IsChecked = true;

            if ((point.X > ActualWidth) && ((double.IsNaN(Width)) || (point.X > Width)))
            {
                Width = point.X;
            }

            if ((point.Y > ActualHeight) && ((double.IsNaN(Height)) || (point.X > Height)))
            {
                Height = point.Y;
            }
            JustOneVertexChecked();
            RepositionAllObjects();
        }

        public void RemoveFamilyMember(Person person)
        {
            foreach (var child in TreeCanvas.Children)
            {
                if (child is Vertex)
                {
                    var vertexPerson = (Person) ((Vertex) child).DataContext;
                    if ((vertexPerson != null) && (vertexPerson.Id == person.Id))
                    {
                        var vertex = (Vertex) child;
                        TreeCanvas.Children.Remove(vertex);

                        var relationship = GetRelationship(vertex);
                        TreeCanvas.Children.Remove(relationship);
                        break;
                    }
                }
            }
        }

        public void UpdateFamilyMember(Person person)
        {
            for (int i = 0; i < TreeCanvas.Children.Count; i++)
            {
                if ((TreeCanvas.Children[i] is Vertex) && ((Vertex) TreeCanvas.Children[i]).IsChecked)
                {
                    ((Vertex) TreeCanvas.Children[i]).DataContext = person;
                    break;
                }
            }
        }

        public Vertex GetMe()
        {
            for (int i = 0; i < TreeCanvas.Children.Count; i++)
            {
                if ((TreeCanvas.Children[i] is Vertex) && ((Person)((Vertex)TreeCanvas.Children[i]).DataContext) is Me)
                {
                    return (Vertex) TreeCanvas.Children[i];
                }
            }
            return null;
        }

        public void Check(Person person)
        {
            if (person != null)
            {
                for (int i = 0; i < TreeCanvas.Children.Count; i++)
                {
                    if ((TreeCanvas.Children[i] is Vertex) &&
                        (((Person) (((Vertex) TreeCanvas.Children[i]).DataContext)).Id ==
                         person.Id))
                    {
                        ((Vertex) TreeCanvas.Children[i]).IsChecked = true;
                        JustOneVertexChecked();
                        return;
                    }
                }
            }
        }

        public Vertex GetCheckedVertex()
        {
            foreach (var child in TreeCanvas.Children)
            {
                if ((child is Vertex) && ((Vertex) child).IsChecked)
                {
                    return (Vertex) child;
                }
            }
            return null;
        }

        public Relationship GetRelationship(Vertex checkedVertex)
        {
            foreach (var child in TreeCanvas.Children)
            {
                if ((child is Relationship) && (((Relationship) child)).firstVertex == checkedVertex)
                {
                    return (Relationship) child;
                }
            }
            return null;
        }

        private void JustOneVertexChecked()
        {
            bool isCheckChanged = false;
            var maybeCheckedVertex = checkedVertex1;
            for (int i = 0; i < TreeCanvas.Children.Count; i++)
            {
                if (TreeCanvas.Children[i] is Vertex && ((Vertex) TreeCanvas.Children[i]).IsChecked)
                {
                    if (!Equals(checkedVertex1, TreeCanvas.Children[i]) && !isCheckChanged)
                    {
                        maybeCheckedVertex = checkedVertex1;
                        checkedVertex1 = (Vertex) TreeCanvas.Children[i];
                        isCheckChanged = true;
                    }
                    else
                    {
                        ((Vertex) TreeCanvas.Children[i]).IsChecked = false;
                    }
                }
            }

            if (Equals(maybeCheckedVertex, checkedVertex1))
            {
                checkedVertex1.IsChecked = true;
            }
        }

        private Point CalculateCoordinates(Vertex vertex, Vertex checkedVertex, KindOfRelative kindOfRelative)
        {
            double left = 0, bottom = 0;
            if (checkedVertex != null)
            {
                if (kindOfRelative == KindOfRelative.Father)
                {
                    left = Canvas.GetLeft(checkedVertex) - offset;
                    bottom = Canvas.GetBottom(checkedVertex) + offset;
                }
                else if (kindOfRelative == KindOfRelative.Mother)
                {
                    left = Canvas.GetLeft(checkedVertex) + offset;
                    bottom = Canvas.GetBottom(checkedVertex) + offset;
                }
                else if (kindOfRelative == KindOfRelative.Brother || kindOfRelative == KindOfRelative.Sister)
                {
                    left = Canvas.GetLeft(checkedVertex) + checkedVertex.Width + offset;
                    bottom = Canvas.GetBottom(checkedVertex);
                }
                else if (kindOfRelative == KindOfRelative.Husband || kindOfRelative == KindOfRelative.Wife)
                {
                    left = Canvas.GetLeft(checkedVertex) - checkedVertex.Width - offset;
                    bottom = Canvas.GetBottom(checkedVertex);
                }
            }
            else
            {
                left = TreeCanvas.ActualWidth/2 - vertex.Width/2;
                bottom = 20;
            }
            Canvas.SetLeft(vertex, left);
            Canvas.SetBottom(vertex, bottom);
            return new Point(left + vertex.Width + offset/2, bottom + vertex.Height + offset/2);
        }

        private void AddRelationship(Vertex vertex, Vertex checkedVertex, KindOfRelative kindOfRelative)
        {
            if (checkedVertex != null)
            {
                double vertexMiddleX, vertexMiddleY;
                if (Canvas.GetBottom(vertex) != Canvas.GetBottom(checkedVertex))
                {
                    vertexMiddleX = Canvas.GetLeft(vertex) + vertex.Width/2;
                    vertexMiddleY = Canvas.GetBottom(vertex) - vertex.Height;
                }
                else if ((kindOfRelative == KindOfRelative.Husband) || (kindOfRelative == KindOfRelative.Wife))
                {
                    vertexMiddleX = Canvas.GetLeft(checkedVertex);
                    vertexMiddleY = Canvas.GetBottom(vertex) + vertex.Height / 2;
                }
                else
                {
                    vertexMiddleX = Canvas.GetLeft(checkedVertex) + checkedVertex.Width;
                    vertexMiddleY = Canvas.GetBottom(vertex) + vertex.Height/2;
                }
                var relationship = new Relationship(vertex, checkedVertex)
                {
                    Line = {X1 = 0, Y1 = 0, Stroke = Brushes.Black, StrokeThickness = 1}
                };

                if (kindOfRelative == KindOfRelative.Father)
                {
                    relationship.Line.X2 = offset;
                    relationship.Line.Y2 = offset/2;
                }
                else if (kindOfRelative == KindOfRelative.Mother)
                {
                    relationship.Line.X2 = -offset;
                    relationship.Line.Y2 = offset/2;
                }
                else if ((kindOfRelative == KindOfRelative.Brother) || (kindOfRelative == KindOfRelative.Sister))
                {
                    relationship.Line.X2 = offset;
                    relationship.Line.Y2 = 0;
                }
                else if ((kindOfRelative == KindOfRelative.Husband) || (kindOfRelative == KindOfRelative.Wife))
                {
                    relationship.Line.X2 = -offset;
                    relationship.Line.Y2 = 0;
                }
                TreeCanvas.Children.Add(relationship);
                Canvas.SetLeft(relationship, vertexMiddleX);
                Canvas.SetBottom(relationship, vertexMiddleY);
            }
        }

        private void TreeCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            JustOneVertexChecked();
            ShowMeTheWay();
        }

        private void ShowMeTheWay()
        {
            var meVertex = GetMe();
            var checkedVertex = GetCheckedVertex();
            var me = (Person)meVertex.DataContext;
            var checkedPerson = (Person)checkedVertex.DataContext;
            var way = new List<KindOfRelative>();

            var queue = new Queue<Person>();
            queue.Enqueue(me);
            //в этом списке будет храниться каждый родственник
            var visitedPoints = new List<Person> { me }; //добавляю себя туда

            Person point;
            Dictionary<Person, KindOfRelative> immediateRelatives;
            var allRelatives = new Dictionary<Person, List<KindOfRelative>>();
            var relationsList = new List<KindOfRelative>();
            Person relative;
            while (queue.Count > 0)//здесь получаем с помощью обхода графа в ширину путь каждом родственнику
            {
                point = queue.Dequeue();
                immediateRelatives = BusinessComponent.GetImmediateRelatives(point.Id);
                foreach (var immediateRelative in immediateRelatives)
                {
                    relative = immediateRelative.Key;
                    queue.Enqueue(relative);
                    visitedPoints.Add(relative);
                    relationsList.Add(immediateRelative.Value);
                    if (allRelatives.ContainsKey(point))
                    {
                        var list = allRelatives[point];
                        relationsList.AddRange(list);
                    }
                    allRelatives.Add(relative, relationsList);
                    if (relative.Id == checkedPerson.Id)
                    {
                        way = relationsList;
                        while (queue.Count > 0)
                        {
                            queue.Dequeue();
                        }
                        break;
                    }
                    relationsList = new List<KindOfRelative>();
                }
            }

            for (int i = 0; i < TreeCanvas.Children.Count; i++)
            {
                if (TreeCanvas.Children[i] is Relationship)
                {
                    ((Relationship)TreeCanvas.Children[i]).Line.Stroke = Brushes.Black;
                }
            }

            var vertex = meVertex;
            var vertex1 = new Vertex();
            KindOfRelative previousKindOfRelative = KindOfRelative.NotRelative;
            KindOfRelative kindOfRelative1 = KindOfRelative.NotRelative;
            var previousVertex = meVertex;

            for (int j = way.Count-1; j >= 0; j--)
            {
                if (kindOfRelative1 == KindOfRelative.NotRelative)
                {
                    kindOfRelative1 = way[j];
                }
                else
                {
                    kindOfRelative1 =
                        RelationshipsDictionary.GetKindOfRelative(new List<KindOfRelative>()
                        {
                            way[j],
                            previousKindOfRelative
                        });
                }
               
                for (int i = 0; i < TreeCanvas.Children.Count; i++)
                {
                    if ((TreeCanvas.Children[i] is Vertex) &&
                        (((Vertex)TreeCanvas.Children[i])).WhoIsRelativeTextBlock.Text ==
                        ConvertTo.String(kindOfRelative1))
                    {
                        vertex1 = (Vertex)TreeCanvas.Children[i];
                        var relationship = GetRelationship(vertex1);
                        if ((relationship.secondVertex == previousVertex) )
                        {
                            break;
                        }
                    }
                }
                previousVertex = vertex1;
                previousKindOfRelative = kindOfRelative1;
                var relationship1 = GetRelationship(vertex1);
                relationship1.Line.Stroke = Brushes.Red;
            }
        }


        #endregion

        public void RepositionAllObjects()
        {
            OffsetNodesHorizontally();
            OffsetNodesVertically();
        }

        private void OffsetNodesVertically()
        {
            double minLeft = Canvas.GetLeft(TreeCanvas.Children[0]);
            foreach (UIElement child in TreeCanvas.Children)
            {
                double left = Canvas.GetLeft(child);
                if (left < minLeft)
                    minLeft = left;
            }

            if (minLeft < 0)
            {
                minLeft = -minLeft;
                foreach (UIElement child in TreeCanvas.Children)
                {
                    Canvas.SetLeft(child, Canvas.GetLeft(child) + minLeft);
                }
            }
        }

        private void OffsetNodesHorizontally()
        {
            double minTop = Canvas.GetTop(TreeCanvas.Children[0]);
            foreach (UIElement child in TreeCanvas.Children)
            {
                double top = Canvas.GetTop(child);
                if (top < minTop)
                    minTop = top;
            }

            if (minTop < 0)
            {
                minTop = -minTop;
                foreach (UIElement child in TreeCanvas.Children)
                    Canvas.SetTop(child, Canvas.GetTop(child) + minTop);
            }
        }
    }
}
