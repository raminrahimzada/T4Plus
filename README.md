##  T4 Plus
## Compile Time Code generation

###  With T4Plus you can generate some repetitive parts of your project </br>

# Example 1 - Class constructors generated automatically by putting just an attribute</br>


<img src="https://i.imgur.com/kIHcy36.png"/>

### Here `AutoCtor` means Automatic Constructor
### T4Plus gives you a writer and your codes write codes <br/>


### And behind the scenes T4Plus will generate codes like that
<img src="https://i.imgur.com/9YGnWhs.png"/>


# Example 2 - Generate class converters with same named properties

### Let's screate a DTO version of that User class
<img src="https://i.imgur.com/AcTm4OT.png"/>

### and the cause of AutoMap attribute T4Plus will automatically generate code like that

<img src="https://i.imgur.com/VATCZFB.png"/>

##  You can see and modify the source code of [AutoCtor](AutoCtor) and [AutoMap](AutoMap) attributes  

## Installation
## There is a generator executable file named `T4Plus.exe` and you should fix its location (or add its path to PATH env variable before usage so can use directly by name)
1. Create New project
2. Add T4Plus dll file or (T4Plus.Core source)
3. Goto Project Properties , Build Events and edit Post-build event command line as following :
  
  ```code
  T4Plus.exe "$(TargetPath)" "$(ProjectDir)\AutoGeneratedClass.cs"
  ```
  
  Or if you T4Plus.exe is not in you 'path'
  ```code
  D:\T4Plus\T4Plus.exe "$(TargetPath)" "$(ProjectDir)\AutoGeneratedClass.cs"
  ```
  
  OK done. when you build your code succcessfully then code generation will occur and your codes will change accordingly <br/>
  so <b> do not forget </b> to rebuild  your project twice after change
