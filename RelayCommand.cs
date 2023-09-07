﻿using System.Diagnostics;
using System;
using System.Windows.Input;

namespace TestGlyphButton
{
   /// <summary>
   /// A command whose sole purpose is to 
   /// relay its functionality to other
   /// objects by invoking delegates. The
   /// default return value for the CanExecute
   /// method is 'true'.
   /// </summary>
   public class RelayCommand : ICommand
   {
      #region Fields

      internal readonly Action _execute;
      internal readonly Func<bool> _canExecute;

      #endregion // Fields

      #region Constructors

      /// <summary>
      /// Creates a new command that can always execute.
      /// </summary>
      /// <param name="execute">The execution logic.</param>
      public RelayCommand( Action execute )
         : this( execute, null )
      {
      }

      /// <summary>
      /// Creates a new command.
      /// </summary>
      /// <param name="execute">The execution logic.</param>
      /// <param name="canExecute">The execution status logic.</param>
      /// <exception cref="ArgumentNullException"><c>execute</c> is null.</exception>
      public RelayCommand( Action execute, Func<bool> canExecute )
      {
         _execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
         _canExecute = canExecute;
      }

      #endregion // Constructors

      #region ICommand Members

      [DebuggerStepThrough]
      public bool CanExecute( object parameter )
      {
         return _canExecute?.Invoke() ?? true;
      }

      public event EventHandler CanExecuteChanged
      {
         add
         {
            if ( _canExecute != null )
               CommandManager.RequerySuggested += value;
         }
         remove
         {
            if ( _canExecute != null )
               CommandManager.RequerySuggested -= value;
         }
      }

      public void Execute( object parameter )
      {
         _execute();
      }

      #endregion // ICommand Members
   }
}