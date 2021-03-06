﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.CodeAnalysis.RuntimeMembers
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Roslyn.Utilities
Imports TypeKind = Microsoft.CodeAnalysis.TypeKind

Namespace Microsoft.CodeAnalysis.VisualBasic

    ''' <summary>
    ''' A ProjectImportsBinder provides the equivalent of a SourceFileBinder, but for the project-level
    ''' imports, which don't live in any file.
    ''' It primarily provides the services of getting locations of nodes, since it holds onto a SyntaxTree, although
    ''' that tree isn't technically a source tree.
    ''' </summary>
    Friend Class ProjectImportsBinder
        Inherits Binder

        ' The syntax tree this binder is associated with
        Private ReadOnly m_tree As SyntaxTree

        Public Sub New(containingBinder As Binder, tree As SyntaxTree)
            MyBase.New(containingBinder)
            m_tree = tree
        End Sub

        Public Overrides Function GetSyntaxReference(node As VisualBasicSyntaxNode) As SyntaxReference
            Return m_tree.GetReference(node)
        End Function
    End Class

End Namespace
