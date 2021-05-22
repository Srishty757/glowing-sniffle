Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication1.WebApplication1

Namespace Controllers
    Public Class EmployeesController
        Inherits System.Web.Mvc.Controller

        Private db As New testDBEntities

        ' GET: Employees
        Function Index() As ActionResult
            Return View(db.Employees.ToList())
        End Function

        ' GET: Employees/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim employee As Employee = db.Employees.Find(id)
            If IsNothing(employee) Then
                Return HttpNotFound()
            End If
            Return View(employee)
        End Function

        ' GET: Employees/Create
        Function Create() As ActionResult
            Return View()
        End Function


        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name,Designation,Location")> ByVal employee As Employee) As ActionResult
            If ModelState.IsValid Then
                db.Employees.Add(employee)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(employee)
        End Function

        ' GET: Employees/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim employee As Employee = db.Employees.Find(id)
            If IsNothing(employee) Then
                Return HttpNotFound()
            End If
            Return View(employee)
        End Function


        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name,Designation,Location")> ByVal employee As Employee) As ActionResult
            If ModelState.IsValid Then
                db.Entry(employee).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(employee)
        End Function

        ' GET: Employees/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim employee As Employee = db.Employees.Find(id)
            If IsNothing(employee) Then
                Return HttpNotFound()
            End If
            Return View(employee)
        End Function

        ' POST: Employees/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim employee As Employee = db.Employees.Find(id)
            db.Employees.Remove(employee)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
