# Fluke Test Application

## Back End Application (.netcore)
Kept the application pretty simple and straight forward as mentioned in the problem document.

**Few Points to note:**

- *Sorting of Events*: 
   While investigating Event model, noticied that it doesn't have any date property as first class citizen, for example below. 
   - So, based upon the model provided by EONET API, only Closed property had the date, based upon with Date Sorting was implemented. 
   - Similarly for Category Sorting as it is a collection, I considered to use the count of the collection to sort Events. 
   - For Status sorting, assumption was that Open events will be sorted at the top and then closed events.

- Swagger: 
  I have added swagger to the service, which is the default page, once your application starts. It has endpoints created in the application, that you can use to test various payload.

#### How to run?

Once you have the code base on you localbox. Just configure the app to run as Project. For your reference, below is launch settings, if you need it.

```json
"Fluke_Test_Project": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
```

#### Could have done?
- This can be configured to run in docker, if your OS supports Hyper-V (mine doesn't as it is Windows-Home version, so I couldn't setup docker-compose for this project.).
- Once docker is setup, then configurations for the application can be moved to enviormemnt variables, to make it more close to cloud application.

## Front End Application (Angular-8)

Front end applcation was developed in Angular8 version, using trival routing for `event` page to dispaly single event.
**Pages:**
- `events` to show all events and to filter and sort out events.
- `event` to show selected event details.

#### How to run?
- Go to the project director i.e. `\Fluke-Front-End` and run `npm install`.
- Once all node modules are installed, run `ng serve`.
- Application would be served at `http://localhost:4200`.

**Note: If you have changed your .netcore application port, then make sure to change it in the `EventsService` as well.**


Please email me on `piyush_sharma_it@yahoo.in` in case of any query.