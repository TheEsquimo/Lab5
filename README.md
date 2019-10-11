# Lab5

# To-Do
ONLY USE BUTTON, LABEL, TEXTBOX AND LISTBOX

CREATE AND CHANGE USERS:
  * Create users:
    - textbox for name
    - textbox for email
    - button to create/submit new user (of class User) to "normal" user-list
  * Change users:
    - reuse name and email textbox
    - button to submit changes to selected user
    - button to be disabled if no user is selected
  * Delete users:
    - button to delete selected user (remove from list)
    - button to be disabled if no user is selected
    
THE LISTS:
  * ListBoxes that contains objects of class User
    - ListBox for "normal/regular" users
    - ListBox for administrator users
  * Users to only be displayed as their names in the lists
  * When a user is selected in a list, display full user-information
    - Label to display full user-information

MOVE USERS:
  * Move users between the lists
    - Button to make selected "normal" user become an admin. Remove from normal list, add to admin-list
      - Button disabled when no "normal" user is selected
    - Button to make selected admin user become a "normal" user. Remove from admin list, add to normal list
      - Button disabled when no admin user is selected
      
USER CLASS:
  * Name property
  * Email property
