# Search Exercise - Delegates and Events Practice

## Objective
Create a `Search` class that searches for files matching a pattern and raises events when files are found. This exercise will help you practice using delegates and events in C#.

## Requirements

### 1. Create the Search Class
Create a class called `Search` with the following functionality:

#### Event Arguments
- Create a custom `EventArgs` class called `FileFoundEventArgs` that contains:
  - `string FilePath` - The full path of the found file
  - `string FileName` - Just the name of the file
  - `long FileSize`  - The size of the file in bytes

#### Events
- Define an event called `FileFound` that fires when a matching file is discovered
- Use `EventHandler<FileFoundEventArgs>` as the event type

#### Properties
- `string SearchPattern` - The file pattern to search for (e.g., "*.txt", "*.cs")
- `string RootDirectory` - The directory to start searching from

#### Methods
- `void StartSearch()` - Begins the search operation
  - Should recursively search through directories
  - Fire the `FileFound` event for each matching file
- `protected void OnFileFound(string filePath)` - Helper method to raise the event

### 2. Implementation Notes
- Use `System.IO.Directory.GetFiles()` and `System.IO.Directory.GetDirectories()` for searching
- Use `System.IO.Path` for working with file paths
- Use `System.IO.FileInfo` to get file details
- Handle potential exceptions (access denied, etc.) gracefully
- **No threading required** - keep the search synchronous for now

### 3. Example Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        Search searcher = new Search
        {
            SearchPattern = "*.cs",
            RootDirectory = @"C:\MyProjects"
        };

        // Subscribe to the event
        searcher.FileFound += Searcher_FileFound;

        // Start the search
        Console.WriteLine("Starting search...");
        searcher.StartSearch();
        Console.WriteLine("Search completed!");
        
        Console.ReadKey();
    }

    private static void Searcher_FileFound(object sender, FileFoundEventArgs e)
    {
        Console.WriteLine($"Found: {e.FileName} ({e.FileSize} bytes)");
    }
}
```

## Bonus Challenges

### Challenge 1: Search Statistics
Add another event called `SearchCompleted` that fires when the search is done, including:
- Total number of files found
- Total size of all files
- Time taken to search

### Challenge 2: Progress Updates
Add a `SearchProgress` event that fires periodically to report:
- Number of directories scanned
- Current directory being searched
- Percentage complete (if possible to estimate)


## Learning Goals
By completing this exercise, you will practice:
- Creating custom EventArgs classes
- Defining and raising events
- Event subscription and unsubscription
- The event pattern in C#
- Working with the file system
- Exception handling
- Separation of concerns (search logic vs. UI/output)


Good luck! 🚀
