$().ready ->
  $('#submit').on 'click', submit
  
submit = ->
  params = 
    Title: $('#Title').val()
    Artist: $('#Artist').val()
    Comment: if $('#Comment').val() is '' then null else $('#Comment').val()
    Url: $('#Url').val()

  Utl.request 'subjects/create', params, onSuccess, onFailure

onSuccess = (res)->

onFailure = (res)->
