install.packages(c("httr", "jsonlite"))
library(httr)
library(jsonlite)

guid <- "paste_your_guid_here"
abn <- "26008672179"


response <- GET("https://abr.business.gov.au/json/AbnDetails.aspx", query = list(guid = guid, abn = abn, callback = "callback"))
removeCallback <- sub('[^\\[|\\{]*', '', response) # remove callback and opening parenthesis
removeClosingParenthesis <- sub('\\);*$', '', removeCallback) # remove closing parenthesis
results <- fromJSON(removeClosingParenthesis)
