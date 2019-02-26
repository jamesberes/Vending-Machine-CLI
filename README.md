# Vending-Machine-CLI
   Command line program that reads in a pipe delimited file and allows the user to select / purchase an item. Writes &amp; updates log files and sales reports for office use.
Module 1 Capstone - Vending Machine Software You’ve been asked to develop an application for the newest vending machine distributor, Umbrella Corp. They’ve released a new vending machine (Vendo-Matic 7000) that is integrated with everyone’s bank accounts allowing customers to purchase products right from their computers for convenience sake. 
 
The requirements for the application are listed below: 
 
1. The vending machine needs to dispense beverages, candy, chips, and gum. a. Each vending machine item has a Name and a Price.  
2. The main menu should display when the software is run presenting the following options: 
 
(1) Display Vending Machine Items (2) Purchase (3) End 
 
3. Vending machine inventory is stocked via an input file. 
4. The vending machine is automatically restocked each time the application runs. 
5. When the customer selects ​(1) Display Vending Machine Items​ they have presented a list of all items in the vending machine, the price, and its quantity remaining. 
   a. Each vending machine product has a slot identifier and a purchase price. 
   b. Each slot in the vending machine has enough room for 5 of that product. 
   c. Every product is initially stocked to the maximum amount. 
   d. A product which has run out should indicate it is SOLD OUT.  
6. When the customer select (3) the program ends. The program continues to run until 3 is selected from the main menu. 
7. When the customer selects ​(2) Purchase​ they are guided through the purchasing process menu: 
 
   (1) Feed Money (2) Select Product (3) Finish Transaction Current Money Provided: $2.00 
   Customers remain in the purchase menu until they select 3 and are returned to the main menu (below). 
   
8. The purchase process flow is as follows 

   a. Selecting ​(1) Feed Money ​A customer can repeatedly feed money into the machine in whole dollar amounts (e.g. $1, $2, $5, $10).         i. The Current Money Provided indicates how much money the customer has fed into the machine. 
   
   b. Selecting ​(2) Select Product ​presents the customer with a list of the items in the vending machine, the price, and its quantity remaining and allows the customer to select a product to purchase. 
      i. If the product code does not exist, the customer is informed and returned to the Purchase menu. 
      ii. If a product is sold out, the customer is informed and returned to the Purchase menu.  
      iii. If a valid product is selected it is dispensed to the customer. 
      iv. The item(s) will be “consumed” and a message printed depending on the item type: 
         1. All chip items (Ax) will return “Crunch Crunch, Yum!” 
         2. All candy items (Bx) will return “Munch Munch, Yum!” 
         3. All drink items (Cx) will return “Glug Glug, Yum!” 
         4. All gum items (Dx) will return “Chew Chew, Yum!” 
      v. After the product is dispensed, the machine should update its balance accordingly and return the customer to the Purchase menu.
      
   c. Selecting ​(3) Finish Transaction​ allows the customer to complete the transaction and receive any remaining change back. 
      i. The customer’s money is returned using nickels, dimes, and quarters (using the smallest amount of coins possible). 
      ii. The machine’s current balance should be updated to $0 remaining. 
      
9. All purchases must be audited to prevent theft from the vending machine 
   a. Each purchase should generate a line in a file called ​Log.txt 
   b. The audit entry should be in the format  
 
10/01/2018 12:00:00 PM FEED MONEY: $5.00 $5.00 
10/01/2018 12:00:15 PM FEED MONEY: $5.00 $10.00 
10/01/2018 12:00:20 PM Crunchie B4 $10.00 $8.50 
10/01/2018 12:01:25 PM Cowtales B2 $8.50 $7.50 
10/01/2018 12:01:35 PM GIVE CHANGE: $7.50 $0.00 
 
10.(Optional) The Main menu can have a hidden option (9) that produces a sales report as shown below. The sales report is produced each time the (9) is selected. The sales 
report shows the sales since the vending machine was started. Each sales report has a unique name that includes the date and time. 
 
Please provide unit tests demonstrating your code works correctly. 
 
Vending Machine Data File The input file that stocks the vending machine products is a pipe | delimited file. Each line is a separate product in the file and follows the below format 
 
Column Name Description Slot Location The slot location in the vending machine where the product is set. Product Name The display name of the vending machine product Price The purchase price for the product. 
 
An example input file has been provided with your repository. Your program may be evaluated with other data that follows this same formatting. 
 
  
Sales Report (Optional) The output sales report file is also pipe delimited for consistency. Each line is a separate product with the number of sales for the applicable product. At the end of the report is a blank line followed by **TOTAL SALES** $dollar amount indicating the gross sales from the vending machine. Sales shown are the sales since the vending machine was started and loaded with product. Each sales report should be written in a file with a unique name that includes the date and time. 
 
Example Output 
 
Potato Crisps|0 
Stackers|1 
Grain Waves|0
Cloud Popcorn|0 
Moonpie|0 
Cowtales|1 
Wonka Bar|0 
Crunchie|0 
Cola|10 
Dr. Salt|0 
Mountain Melter|0 
Heavy|0 
U-Chews|0 
Little League Chew|0 
Chiclets|0 
Triplemint|0 
 ** TOTAL SALES **  $2.95 
 
