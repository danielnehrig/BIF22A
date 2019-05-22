# Project Information

LIB = -r:./packages/System.Data.SqlClient.4.6.1/lib/net46/System.Data.SqlClient.dll \
 			-r:./packages/Avalonia.0.8.0/lib/net461/Avalonia.dll \
			-r:./packages/Avalonia.Desktop.0.8.0/lib/netstandard2.0/Avalonia.Desktop.dll \
			-r:./packages/Avalonia.Native.0.8.0/lib/netstandard2.0/Avalonia.Native.dll

PKG = 
PWD = $(shell pwd)
COMP = csc
SRCPATH = ./src/
COMPILEPATH = ./dist/
FILENAME = KaffeeKasse.exe

BASEFILES = $(SRCPATH)Types/Item.cs $(SRCPATH)Types/ItemLog.cs $(SRCPATH)Types/Teacher.cs \
						$(SRCPATH)Types/Users.cs $(SRCPATH)Views/MainWindow.xaml.cs $(SRCPATH)Views/App.xaml.cs \
						$(SRCPATH)Administration.cs

CONSOLE = $(SRCPATH)Program.cs

BuildConsole:
	$(COMP) $(BASEFILES) $(CONSOLE) $(LIB) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)

Clean:
	rm $(COMPILEPATH)*.exe

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)

Install:
	mkdir packages
	cd packages
	nuget install Avalonia
	nuget install Avalonia.Desktop
	nuget install System.Data.SqlClient
