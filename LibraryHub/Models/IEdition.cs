namespace LibraryHub.Models;

/// <summary>
/// Each edition its own state definition and validation
/// The method return a new edition instead of void to ensure that a newly  created edition is always the expected edition
/// if void had been used, then on each call of the method the value is incremented
/// </summary>
public interface IEdition
{
   IEdition AdvanceToNext();
}