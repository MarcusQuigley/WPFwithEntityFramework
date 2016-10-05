using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quigley.Model.Behaviours
{
   public static class ListBoxBehaviour
    {
         public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ListBoxBehaviour), new PropertyMetadata(SetupCommandCallback));

        private static void SetupCommandCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listbox = d as ListBox;
            if (listbox !=null)
                listbox.SelectionChanged += listbox_SelectionChanged;

        }

        static void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            ICommand command = GetCommand(listbox);
            if (command != null)
            {
                object param = GetCommandParameter(listbox);
                if (command.CanExecute(param))
                    command.Execute(param);
            }
        }



        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", 
            typeof(object), typeof(ListBoxBehaviour));       

    }
}
