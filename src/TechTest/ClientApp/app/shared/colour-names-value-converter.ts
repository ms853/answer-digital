import { IColour } from '../people/interfaces/icolour';

export class ColourNamesValueConverter {

  toView(colours: IColour[]) {

    // TODO: Step 4
    //
    // Implement the value converter function.
    // Using the colours parameter, convert the list into a comma
    // separated string of colour names. The names should be sorted
    // alphabetically and there should not be a trailing comma.
    //
      // Example: 'Blue, Green, Red'

      //colours.sort();
      //colours.join();
      

      colours.forEach(c => {    
          var result = c.name.split(',')
          result.sort();
          result.join();
          console.log("colour array: " + result);
          return result;
      });

 
    return colours;
  }

}
