/*
using System.Text.Json;

// this is a design pattern to abstract the data away from implementation
// repository can be calling methods without worrying about details.
namespace DL;

public class FileRepository :IRepository
{
    private readonly string filePath = "../DL/StackLite.json";
    /// <summary>
    /// Retrieves all Issues from StackLite.json
    /// </summary>
    /// <returns>List of Issues, if there is none, returns an empty list</returns>
    public List<Customer> GetAllCustomer()
    {
        //We are first initializing a string variable to hold the result of the file read
        string jsonString = "";

        try
        {
            //and we are taking File class's ReadAllText method to read the content in the file path we have specified
            //There is a chance that it can throw an exception, so we wrap this in try/catch block.
            jsonString = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            //this block gets executed regardless of whether we have caught an exception or not
        }

        List<Issue> issues = new List<Issue>();
        try
        {
            issues = JsonSerializer.Deserialize<List<Issue>>(jsonString) ?? new List<Issue>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine("There was an issue with the format of jsonString");
            Console.WriteLine(ex.Message);
        }
        return issues;
    }

    /// <summary>
    /// Inserts a new json issue object to StackLite.json
    /// </summary>
    /// <param name="issueToCreate">An issue object to be inserted</param>
    public void CreateIssue(Issue issueToCreate)
    {
        /*
        * 1. I want to make sure I have a thing to add
        * 2. I want to grab all questions from my list of questions
        *   2a. Reading from the file and Deserializing
        * 3. I want to add my new question to the end of my list of questions
        * 4. I want to write that back into my file
        *   4a. Serializing List<Issue> to string and writing to the file.
        *
        *

        if(issueToCreate == null) throw new ArgumentNullException();

        List<Issue> allIssues = GetAllIssues();
        allIssues.Add(issueToCreate);

        string jsonString = JsonSerializer.Serialize(allIssues);
        File.WriteAllText(filePath, jsonString);
    }

    public void AddAnswer(Issue issueToUpdate)
    {
        if(issueToUpdate == null) throw new ArgumentNullException();
        List<Issue> allIssues = GetAllIssues();

        Issue foundIssue = allIssues.FirstOrDefault(q => q.Title == issueToUpdate.Title && q.Content == issueToUpdate.Content);

        foundIssue.Answers = issueToUpdate.Answers;

        string jsonString = JsonSerializer.Serialize(allIssues);
        File.WriteAllText(filePath, jsonString);
    }
}
*/